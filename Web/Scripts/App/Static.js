(function ($, window, undefined) {

    function StaticImpl() {
        this.formatBytes = function (bytes) {
            if (bytes == 0)
                return '0 B';

            var a = bytes;
            var b = Math.log2(a);
            var c = Math.floor(b / 10);

            var num = Math.round2(a / Math.pow(2, c * 10));
            var unit = (c == 0 ? 'B' : ' KMGT'[c] + 'B');

            return num + ' ' + unit;
        };
    }

    window.Static = $.extend(window.Static, new StaticImpl());

})(window.jQuery, window);
