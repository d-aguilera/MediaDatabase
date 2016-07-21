Math.round2 = Math.round2 || function (x) {
    return Math.round((x + 0.00001) * 100) / 100;
}

Math.log2 = Math.log2 || function (x) {
    return Math.log(x) / Math.LN2;
};
