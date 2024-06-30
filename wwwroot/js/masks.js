window.addEventListener("DOMContentLoaded", () => {
  mascararCpf();
  mascararTelefone();
});

function mascararCpf() {
  [...document.getElementsByClassName("mascara-cpf")].forEach((element) => {
    console.log("0", element);

    const mascarar = (mElement) => {
      if (mElement.value) mElement.value = aplicarMascaraCpf(mElement.value);
      if (mElement.innerText)
        mElement.innerText = aplicarMascaraCpf(mElement.innerText);
    };
    element.addEventListener("keyup", () => {
      mascarar(element);
    });
    element.addEventListener("change", () => {
      mascarar(element);
    });
    mascarar(element);
  });
}

function aplicarMascaraCpf(text) {
  console.log(text, "1");
  text = text.replaceAll(/\D/g, "");
  let ret = "";
  for (let i = 0; i < text.length; i++) {
    if (i > 10) break;
    if ([3, 6].includes(i)) ret += ".";
    if (i == 9) ret += "-";
    ret += text[i];
  }
  return ret;
}

function aplicarMascaraTelefone(text) {
  text = text.replaceAll(/\D/g, "");
  let ret = "(";
  for (let i = 0; i < text.length; i++) {
    if (i > 10) break;
    if (i == 2) ret += ")";
    if ((i == 6 && text.length <= 10) || (i == 7 && text.length > 10))
      ret += "-";
    ret += text[i];
  }
  return ret;
}

function mascararTelefone() {
  [...document.getElementsByClassName("mascara-telefone")].forEach(
    (element) => {
      const mascarar = (mElement) => {
        if (mElement.value && mElement.value.length > 0) {
          mElement.value = aplicarMascaraTelefone(mElement.value);
        }

        if (mElement.innerText && mElement.innerText.length > 0) {
          mElement.innerText = aplicarMascaraTelefone(mElement.innerText);
        }
      };
      element.addEventListener("keyup", () => {
        mascarar(element);
      });
      element.addEventListener("change", () => {
        mascarar(element);
      });
      mascarar(element);
    }
  );
}
