function showEnd() {
    var titulo = document.querySelector('.showEnd')
    var selDiv = document.querySelector('.endereco');
    titulo.addEventListener('click', () => {
        selDiv.classList.toggle('ativo');
        titulo.classList.toggle('ativo');
    });
}

/*Consultar CEP*/

function buscarcep() {
    const cep = document.querySelector("#cep")

    const showcep = (result) => {
        for (const campo in result) {
            if (document.querySelector("#" + campo)) {
                document.querySelector("#" + campo).value = "";
                document.querySelector("#" + campo).value = result[campo]
            }
        }
    }

    cep.addEventListener("blur", (e) => {
        let search = cep.value.replace("-", "")
        const options = {
            method: 'GET',
            mode: 'cors',
            cache: 'default'
        }

        fetch(`https://viacep.com.br/ws/${search}/json/`, options)
            .then(response => {
                response.json()
                    .then(data => showcep(data))
            })
            .catch(e => console.log('Error: ' + e, message))
    })
}