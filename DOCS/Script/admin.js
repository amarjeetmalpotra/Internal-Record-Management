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
function dis() {
    document.getElementById('note').style.display = 'block';

}
function wrkspce() {
    document.getElementById('add_user').style.display = 'none';
    document.getElementById('txtname').value = '';
    document.getElementById('txtuser').value = '';
    document.getElementById('txtpass').value = '';
    document.getElementById('note').style.display = 'none';
    document.getElementById('dash_board').style.display = 'block';

}
function adduser() {
    document.getElementById('add_user').style.display = 'block';
    document.getElementById('dash_board').style.display = 'none';
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