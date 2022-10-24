console.log("Abc".includes("b"));

const input = document.getElementById("searchBox");
const nameList = document.getElementById("nameList");
const names = nameList.getElementsByTagName("li");

console.log(names);
input.addEventListener('input', updateValue);

function updateValue(e) {
    for (var i = 0; i < names.length; i++) {
        if(names[i].textContent.includes(e.target.value) && e.target.value !== "") {
            names[i].style.fontWeight = "bold";
        } else {
            names[i].style.fontWeight = "normal";
        }
      }
    };

