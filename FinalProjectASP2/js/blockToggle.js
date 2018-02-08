function toggleForm(element) {
    $(element).find('#searchPatientByName').fadeToggle();
}

function setSlide() {
    sessionStorage.setItem("TABLE_SLIDE", 'true');
}

function slideTable() {
    if (sessionStorage.getItem("TABLE_SLIDE") == 'true') {
        $("#selector").fadeOut(new function () {

        });
    }
}