var input = document.querySelectorAll('.targetname');

var lengthVal = function (event, max) {

    var currentInput = event.target
    var $elemId = $(currentInput).attr('id');

    var $elemLabel = $elemId + 'Id';
    var $elemLength = max - currentInput.value.length;

    if ($elemLength <= 1) {
       $elemLength = 0
    }

    $(function () {
        $(currentInput).focusin(function () {
            $('#' + $elemLabel).show();
        }).focusout(function () {
            $('#' + $elemLabel).hide();
        });
    });


    if (!$('#' + $elemLabel).length == 0) {
        $('#' + $elemLabel).text($elemLength + " characters left")

    } else {
        $(currentInput).after("<span id=" + $elemLabel + "> " + $elemLength + " characters left.</span>");
    }
    
}

if (input) {
    input.forEach((element) => {
        element.addEventListener('keyup', function (e) {
            var length = element.dataset.maxLength;
            lengthVal(e, length)
        })
    });
}

const toggle = document.querySelector(".toggle");
const menu = document.querySelector(".menu");
const items = document.querySelectorAll(".item");

/* Toggle mobile menu */
function toggleMenu() {
  if (menu.classList.contains("active")) {
    menu.classList.remove("active");
    toggle.querySelector("a").innerHTML = "<i class='fas fa-bars'></i>";
  } else {
    menu.classList.add("active");
    toggle.querySelector("a").innerHTML = "<i class='fas fa-times'></i>";
  }
}

/* Activate Submenu */
function toggleItem() {
  if (this.classList.contains("submenu-active")) {
    this.classList.remove("submenu-active");
  } else if (menu.querySelector(".submenu-active")) {
    menu.querySelector(".submenu-active").classList.remove("submenu-active");
    this.classList.add("submenu-active");
  } else {
    this.classList.add("submenu-active");
  }
}

/* Close Submenu From Anywhere */
function closeSubmenu(e) {
  let isClickInside = menu.contains(e.target);

  if (!isClickInside && menu.querySelector(".submenu-active")) {
    menu.querySelector(".submenu-active").classList.remove("submenu-active");
  }
}
/* Event Listeners */
toggle.addEventListener("click", toggleMenu, false);
for (let item of items) {
  if (item.querySelector(".submenu")) {
    item.addEventListener("click", toggleItem, false);
  }
  item.addEventListener("keypress", toggleItem, false);
}
document.addEventListener("click", closeSubmenu, false);