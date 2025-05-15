document.addEventListener("DOMContentLoaded", function () {
    const gradeCells = document.querySelectorAll('.grade');
    gradeCells.forEach(function (cell) {
        switch (parseInt(cell.textContent)) {
            case 6:
                cell.style.color = "white"; 
                break;
            case 5:
                cell.style.color = "lime";
                break;
            case 4:
                cell.style.color = "green";
                break;
            case 3:
                cell.style.color = "yellow";
                break;
            case 2:
                cell.style.color = "orange";
                break;
            case 1:
                cell.style.color = "red";
                break;
            default:
                cell.style.color = "#FF00D2";
        }
    });
});