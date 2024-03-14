window.downloadPDF = function (elementId) {
    var element = document.getElementById(elementId);
    if (element) {
        var pdf = new jsPDF();
        pdf.text(10, 10, 'PDF Title');
        pdf.fromHTML(element, 10, 20);
        pdf.save('tab_component.pdf');
    } else {
        console.error("Element with id '" + elementId + "' not found.");
    }
};