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
function logout() {
    var ask = window.confirm("You will be Logged Out...Are you sure ?");
    if (ask) {
        window.location.href = "Home.aspx";
    }
}
/*Disable Back Button*/
function changeHashOnLoad() {
    window.location.href += "#";
    setTimeout("changeHashAgain()", "50");
    if (history.length > 0) history.go(+1);/*Prevent Back Even After Logout*/
}

function changeHashAgain() {
    window.location.href += "1";
}

var storedHash = window.location.hash;
window.setInterval(function () {
    if (window.location.hash != storedHash) {
        window.location.hash = storedHash;
    }
}, 50);
/*Disable Back Button End*/
function dis() {
    document.getElementById("controls").style.display = "block";
    document.getElementById("note").style.display = "block";
}
/*Printing*/
function printDiv() {
    var printContents = document.getElementById("prnt").innerHTML;
    var originalContents = document.body.innerHTML;
    document.body.innerHTML = printContents;
    window.print();
    document.body.innerHTML = originalContents;
}