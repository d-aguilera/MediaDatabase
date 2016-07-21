function ScanProgressViewModel() {
    var self = this;

    function Status(name) {
        var statusPropertyName = name + 'Status';
        this.status = ko.pureComputed(function () {
            return self.input()[statusPropertyName];
        });
        this.icon = ko.pureComputed(function () {
            var taskStatus = self.input()[statusPropertyName];
            switch (taskStatus) {
                case 3:
                case 4: return {
                    'class': 'glyphicon glyphicon-refresh glyphicon-spin',
                    'style': 'color: inherit',
                };
                case 5: return {
                    'class': 'glyphicon glyphicon-ok',
                    'style': 'color: green',
                };
                case 6:
                case 7: return {
                    'class': 'glyphicon glyphicon-remove',
                    'style': 'color: red',
                };
                default: return {
                    'class': 'glyphicon glyphicon-none',
                    'style': 'color: inherit',
                };
            }
        });
    }

    function Counter(name) {
        var counter = function () {
            return self.input()[name];
        };
        this.items = ko.pureComputed(function () {
            return counter().Items;
        });
        this.bytes = ko.pureComputed(function () {
            return counter().Bytes;
        });
        this.bytesFormatted = ko.pureComputed(function () {
            return Static.formatBytes(counter().Bytes);
        });
    }

    self.input = ko.observable().extend({ 'defaultScanProgressViewModel': null });

    self.overallStatusSummary = ko.pureComputed(function () {
        var sar = self.input();
        switch (sar.OverallStatus) {
            case -2: return 'Disconnected.';
            case -1: return 'Idle.';
            case 3:
            case 4: return 'Scanning ' + sar.Path + ' - ' + sar.HashingProgress + '%';
            case 5: return 'Scan of ' + sar.Path + ' completed.';
            case 6: return 'Scan of ' + sar.Path + ' canceled.';
            case 7: return 'Scan of ' + sar.Path + ' finished with errors.';
            default: return 'Disconnected.';
        }
    });

    self.overallStatus = ko.pureComputed(function () {
        var sar = self.input();
        return sar.OverallStatus;
    });

    self.scanning = $.extend(new Counter('Scanned'));
    self.discovery = $.extend(new Status('Discovery'), new Counter('Discovered'));
    self.hashing = $.extend(new Status('Hashing'), new Counter('Hashed'));
    self.saving = $.extend(new Status('Saving'), new Counter('Saved'));

    self.getBarAttrBinding = function () {
        var sar = self.input();
        var width = sar.Hashed.Bytes > 0 ? sar.HashingProgress : 0;
        return {
            'style': 'width: ' + width + '%; height: 100%'
        };
    }

    var handle;

    function getScanAsyncResult() {
        var myHub = SignalRManager.myHub();
        if (myHub && myHub.server) {

            var func = myHub.server.getScanAsyncResult;

            if (typeof (func) === 'function')
                func().done(function (sar) {
                    self.input($.extend({}, { overallStatus: -1 }, sar));
                });
        }
        else
        {
            debugger;
        }
    }

    SignalRManager.connection.status.subscribe(function (newValue) {
        switch (newValue) {
            case 2:
                getScanAsyncResult();
                handle = setInterval(getScanAsyncResult, 1000);
                break;

            default:
                if (handle)
                    clearInterval(handle);
                break;
        }
    });

    self.initSignalR = function (url) {
        SignalRManager.init(url);
    };
}
