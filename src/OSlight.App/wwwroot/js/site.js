function showEnd() {
    var titulo = document.querySelector('.showEnd')
    var selDiv = document.querySelector('.endereco');
    titulo.addEventListener('click', () => {
        selDiv.classList.toggle('ativo');
        titulo.classList.toggle('ativo');
    });
}