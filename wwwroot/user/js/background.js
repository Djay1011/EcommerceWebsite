var content = document.getElementsByTagName('body')[0];
var mode = document.getElementById('light');

let getTheme = localStorage.getItem('theme')
if (getTheme && getTheme === 'dark'){
    content.classList.add('night');
    mode.classList.add('active');
}
mode.addEventListener('click', function(){
    content.classList.toggle('night');
    mode.classList.toggle('active');

    if (!content.classList.contains('night')) {
        return localStorage.setItem('theme', 'light');
    }
    localStorage.setItem('theme', 'dark');
});
