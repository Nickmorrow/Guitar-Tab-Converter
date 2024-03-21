
window.printContent = function (elementId) {
    var element = document.getElementById(elementId);
    if (element) {
        var printWindow = window.open('', '_blank');
        printWindow.document.open();
        printWindow.document.write('<html><head><title>Print</title><link rel="stylesheet" type="text/css" href="tabcomponentPrint.css"></head><body onload="window.print();">');

        printWindow.document.write(element.innerHTML);

        printWindow.document.write('</body></html>');
        printWindow.document.close();
    } else {
        console.error("Element with id '" + elementId + "' not found.");
    }
};
