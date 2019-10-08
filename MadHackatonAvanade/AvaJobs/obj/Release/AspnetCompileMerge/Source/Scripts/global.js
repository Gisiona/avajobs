if (localStorage.getItem("user") != null) {
    $(".nologado").hide();
    var user = JSON.parse(localStorage.getItem("user"));
    var userhmtl = user.firstName + " " + user.lastName;
    $("#dataUser").html(userhmtl);
    $(".logado").show();

} else {
    $(".logado").html('');
    $(".logado").hide();
    $(".nologado").show();
}
function logout() {
    localStorage.removeItem("user");
    $(".nologado").show();
    $(".logado").hide();
    $("#dataUser").html('');
}