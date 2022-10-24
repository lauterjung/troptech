const input = document.getElementById("searchBox");
const table = document.getElementById("table");

input.addEventListener('input', updateValue);

function updateValue(e) {
    for (var i = 0; i < table.rows.length; i++) {
        console.log(table.rows[i]);
        if(table.rows[i].cells[0].textContent.includes(e.target.value) && e.target.value !== "") {
            table.rows[i].style.fontWeight = "bold";
            table.rows[i].cells[0].style.color = "#ff0000";
            table.rows[i].cells[1].style.color = "#ff0000";
        } else {
            table.rows[i].style.fontWeight = "normal";
            table.rows[i].cells[0].style.color = "black";
            table.rows[i].cells[1].style.color = "black";
        }
      }
    };


