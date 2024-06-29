window.addEventListener("DOMContentLoaded", () => {
  const urlParams = new URLSearchParams(window.location.search);
  const tipoAlerta = urlParams.get("tipoAlerta");
  const mensagem = urlParams.get("mensagem");
  if (tipoAlerta && mensagem && tipoAlerta.length > 0 && mensagem.length > 0)
    alerta(tipoAlerta, mensagem);
});

function alerta(tipoAlerta, mensagem) {
  let icon;
  let title;
  switch (tipoAlerta.toLowerCase()) {
    case "sucesso":
      icon = "success";
      title = "Sucesso";
      break;
    case "erro":
      icon = "error";
      title = "Erro";
      break;
    default:
      return;
  }
  Swal.fire({
    title,
    text: mensagem,
    icon,
  });
  window.history.replaceState({}, "", `${window.location.pathname}`);
}
