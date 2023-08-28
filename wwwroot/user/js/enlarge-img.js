document.querySelectorAll('.top-img img').forEach(image =>{
    image.onclick = () =>{
        document.querySelector('.enlarge').style.display = 'block';
        document.querySelector('.enlarge img').src = image.getAttribute('src')
    }
});

document.querySelector('.enlarge i').onclick = () =>{
    document.querySelector('.enlarge').style.display = 'none';
}
