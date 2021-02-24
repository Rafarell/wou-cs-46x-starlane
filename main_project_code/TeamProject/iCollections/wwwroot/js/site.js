﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

//    SHOW UPLOADED IMAGE
function readURL(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#imageResult')
                .attr('src', e.target.result);
        };
        reader.readAsDataURL(input.files[0]);
        showFileName();
        $("#customNameError").hide();
        $("#uploadPhotoError").hide();

    }
    else {
        alert("Please enter an image.")
    }
}

$('#upload').on('change', function () {
    readURL(input);
});


//    SHOW UPLOADED IMAGE NAME

var input = document.getElementById('upload');
var infoArea = document.getElementById('upload-label');

function showFileName() {
    var fileName = input.files[0].name;
    infoArea.textContent = 'File name: ' + fileName;
}

// check if the optional input is correct format 
// and if photo is uploaded
$("#photoUpload").submit(function (event) {
    var optionalName = $("#customName").val();
    if (optionalName !== "") {
        if (!optionalName.replace(/\s/g, '').length) {
            $("#customNameError").text("names must have letters and/or numbers.").show();
            event.preventDefault();
        }
    }

    var fileUpload = $("#upload")[0];
    if (fileUpload.files.length === 0) {
        $("#uploadPhotoError").text("please upload an image.").show();
        event.preventDefault();
    }

});