/* Toggle between adding and removing the "responsive" class to topnav when the user clicks on the icon */
function myFunction() {
    var x = document.getElementById("myTopnav");
    if (x.className === "topnav") {
        x.className += " responsive";
    } else {
        x.className = "topnav";
    }
}
/*Loading Gif Script*/
$(window).load(function () {
    $(".loader").fadeOut("slow");;
});
/*Login Script*/
function openForm() {
    document.getElementById("stud").style.display = "none";
    document.getElementById("myForm").style.display = "block";
}

function closeForm() {
    document.getElementById("myForm").style.display = "none";
}
function disp() {
    document.getElementById("myForm").style.display = "none";
    document.getElementById("stud").style.display = "block";
}
