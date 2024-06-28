window.addEventListener("DOMContentLoaded", () => {
  mascararCpf();
  mascararTelefone();
});

function mascararCpf() {
  [...document.getElementsByClassName("mascara-cpf")].forEach((input) => {
    const mascarar = (input) => {
      const text = input.value.replaceAll(/\D/g, "");
      console.log("Teste",text)
      let ret = "";
      for (let i = 0; i < text.length; i++) {
        if(i>10) break;
        if ([3, 6].includes(i)) ret += ".";
        if (i == 9) ret += "-";
        ret += text[i];
      }
      input.value = ret;
    };
    input.addEventListener("keyup", () => {
      mascarar(input);
    });
    input.addEventListener("change", () => {
      mascarar(input);
    });
    mascarar(input);
  });
}

function mascararTelefone() {
  [...document.getElementsByClassName("mascara-telefone")].forEach((input) => {
    const mascarar = (input) => {
      const text = input.value.replaceAll(/\D/g, "");
      if (text.length > 0) {
        let ret = "(";
        for (let i = 0; i < text.length; i++) {
          if(i>10) break;
          if (i == 2) ret += ")";
          if ((i == 6 && text.length <= 10) || (i == 7 && text.length > 10))
            ret += "-";
          ret += text[i];
        }
        input.value = ret;
      }
    };
    input.addEventListener("keyup", () => {
      mascarar(input);
    });
    input.addEventListener("change", () => {
      mascarar(input);
    });
    mascarar(input);
  });
}
