ko.extenders.defaultScanProgressViewModel = function (target) {
    var defaults = {
        ScanRequestId: null,
        Path: null,
        OverallStatus: -1, // uninitialized
        Scanned: { Items: 0, Bytes: 0, },
        DiscoveryStatus: 0,
        Discovered: { Items: 0, Bytes: 0, },
        DiscoveryProgress: 0,
        HashingStatus: 0,
        Hashed: { Items: 0, Bytes: 0, },
        HashingProgress: 0,
        SavingStatus: 0,
        Saved: { Items: 0, Bytes: 0, },
        SavingProgress: 0,
    };
    var result = ko.pureComputed({
        read: target,
        write: function (newValue) {
            var merged = $.extend({}, defaults, newValue);
            target(merged);
        }
    });

    result(target());

    return result;
};

var vm = new ScanProgressViewModel();
ko.applyBindings(vm);

vm.initSignalR('http://localhost:8080/signalr');
