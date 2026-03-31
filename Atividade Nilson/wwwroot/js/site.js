document.addEventListener("DOMContentLoaded", function () {
    const campoCep = document.querySelector(".cep");

    if (!campoCep) return;

    campoCep.addEventListener("blur", async function () {
        const cep = campoCep.value.replace(/\D/g, "");

        if (cep.length !== 8) return;

        try {
            const resposta = await fetch(`https://viacep.com.br/ws/${cep}/json/`);
            const dados = await resposta.json();

            if (dados.erro) return;

            const estado = document.getElementById("Estado");
            const cidade = document.getElementById("Cidade");
            const bairro = document.getElementById("Bairro");
            const logradouro = document.getElementById("Logradouro");
            const complemento = document.getElementById("Complemento");

            if (estado) estado.value = dados.uf || "";
            if (cidade) cidade.value = dados.localidade || "";
            if (bairro) bairro.value = dados.bairro || "";
            if (logradouro) logradouro.value = dados.logradouro || "";
            if (complemento) complemento.value = dados.complemento || "";
        }
        catch (erro) {
            console.error("Erro ao buscar CEP:", erro);
        }
    });
});