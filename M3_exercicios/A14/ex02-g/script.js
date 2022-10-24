
const gallery = document.getElementById("gallery");

const manipuladorClick = (evento) => {
    const img = evento.target;
    if(img.tagName === 'IMG') {
        const div = img.parentElement;
        div.className = 'imagem imagem--visivel';
    }
    if(img.tagName === 'SPAN') {
        const div = img.parentElement;
        div.className = 'imagem';
    }
}

gallery.addEventListener('click', manipuladorClick);