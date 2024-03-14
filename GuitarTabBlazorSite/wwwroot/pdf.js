window.BlazorDownloadFile = function (fileName, content) {
    var link = document.createElement('a');
    link.href = "data:application/pdf;base64," + content;
    link.download = fileName;
    link.target = "_blank";
    document.body.appendChild(link);
    link.click();
    document.body.removeChild(link);
};