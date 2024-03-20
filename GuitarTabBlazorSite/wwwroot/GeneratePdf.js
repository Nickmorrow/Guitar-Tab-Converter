
window.GeneratePdf = function (htmlContent, fileName) {
    var doc = new jsPDF();
    doc.fromHTML(htmlContent, 15, 15); 
    doc.save(fileName);
};

