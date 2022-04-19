// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

let button1=document.querySelector(`#view`);
let button2=document.querySelector(`#close`);
let veiw1= document.querySelector(`#div-view`);

button1.addEventListener(`click`, function () {
    veiw1.classList.add(`active`);
});
button2.addEventListener(`click`, function () {
    veiw1.classList.remove(`active`);
});