window.CaptureHtml = function (elementId) {
    var element = document.getElementById(elementId);
    return element.innerHTML;
};