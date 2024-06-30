const CLASS_ASSOCIADO_CARD = "associado-card";
const CLASS_ASSOCIADO_CARD_EXPANDED = "associado-card-expanded";
const CLASS_ASSOCIADOS_CARDS = "associados-cards";
const CLASS_ASSOCIADO_OCULTO = "associado-oculto";
const CLASS_ACARD_INFO = "acard-info";
const CLASS_ASSOCIADOS_SEARCH = "associados-search";
window.addEventListener("DOMContentLoaded", () => {
  getAllCards().forEach((card) => {
    configureHeaderClick(card);
  });
  const inputSearch = getSearchInput();
  if (inputSearch) {
    inputSearch.addEventListener("keyup", () => {
      searchAssociadoCard(inputSearch);
    });
    inputSearch.addEventListener("change", () => {
      searchAssociadoCard(inputSearch);
    });
  }
});

function searchAssociadoCard(inputSearch) {
  const text = inputSearch.value;
  const cards = getAllCards();
  cards.forEach((card) => {
    card.classList.remove(CLASS_ASSOCIADO_OCULTO);
  });
  if (text.length > 0) {
    cards.forEach((card) => {
      const infos = [
        "nome",
        "telefone",
        "cpf",
        "veiculos-quantidade",
        "estado",
        "cidade",
        "bairro",
        "rua",
        "numero",
        "complemento",
      ];
      for (const info of infos) {
        console.log(info, getAssociadoCardInfo(card, info));
        if (
          getAssociadoCardInfo(card, info)
            .toLowerCase()
            .startsWith(text.toLowerCase())
        )
          return;
      }
      card.classList.add(CLASS_ASSOCIADO_OCULTO);
    });
  }
}

function configureHeaderClick(card) {
  const header = card.getElementsByTagName("header")[0];
  header.addEventListener("click", () => {
    console.log("Teste");
    if (card.classList.contains(CLASS_ASSOCIADO_CARD_EXPANDED)) {
      card.classList.remove(CLASS_ASSOCIADO_CARD_EXPANDED);
      return;
    }
    card.classList.add(CLASS_ASSOCIADO_CARD_EXPANDED);
  });
}

function getAllCards() {
  return [...document.getElementsByClassName(CLASS_ASSOCIADO_CARD)];
}

function getAssociadoCardInfo(card, info) {
  const infos = [...card.getElementsByClassName(CLASS_ACARD_INFO)];
  for (const cardInfo of infos) {
    if (cardInfo.dataset.type.toLowerCase() == info.toLowerCase())
      return cardInfo.innerText;
  }
  return null;
}

function isAssociadoOculto(card) {
  return card.classList.contains(CLASS_ASSOCIADO_OCULTO);
}

function getSearchInput() {
  const searchDiv = document.getElementsByClassName(CLASS_ASSOCIADOS_SEARCH)[0];
  if (searchDiv) return searchDiv.getElementsByTagName("input")[0];

  return null;
}
