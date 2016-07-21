(function ($, window, undefined) {

    function SignalRManagerImpl() {
        var self = this;

        function onConnecting() {
            self.connection.status(1);
        }

        function onConnected() {
            self.connection.status(2);
        }

        function onConnectionSlow() {
            self.connection.status(3);
        }

        function onReconnecting() {
            self.connection.status(4);
        }

        function onDisconnected() {
            self.connection.status(0);
        }

        function disconnect() {
            $.connection.hub.stop();
        }

        function init() {
            var dfd = $.Deferred(function () {

                onConnecting();

                $.getScript(self.url + "/hubs")
                    .done(function (script, textStatus) {

                        var hub = $.connection.hub;

                        hub.url = self.url;
                        hub.logging = true;

                        hub.connectionSlow(onConnectionSlow);
                        hub.reconnecting(onReconnecting);
                        hub.reconnected(onConnected);
                        hub.disconnected(onDisconnected);

                        $.connection.myHub.client.disconnect = disconnect;

                        hub.start()
                            .done(function () {
                                onConnected();
                                dfd.resolve();
                            })
                            .fail(function () {
                                onDisconnected();
                                dfd.reject();
                            });
                    })
                    .fail(function () {
                        onDisconnected();
                        dfd.reject();
                    });
            });
            return dfd;
        }

        self.url = null;
        
        self.connection = {
            status: ko.observable(),
            statusDescription: ko.pureComputed(function () {
                switch (self.connection.status()) {
                    case 0: return 'Offline.';
                    case 1: return 'Connecting...';
                    case 2: return 'Connected.';
                    case 3: return 'Slow...';
                    case 4: return 'Reconnecting...';
                    default:
                }
            }),
        };

        self.myHub = ko.pureComputed(function () {
            return $.connection.myHub;
        });

        self.init = function (url) {
            self.url = url;
            return init();
        };
    };

    window.SignalRManager = $.extend(window.SignalRManager, new SignalRManagerImpl());

})(window.jQuery, window)
