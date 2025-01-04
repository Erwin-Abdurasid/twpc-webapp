function makeUpdateQtyButtonVisible(id, visible) {
    const updateQtyButton = document.querySelector('button[data-id="' + id + '"]');

    if (visible == true) {
        updateQtyButton.style.display = "inline-block";
    } else {
        updateQtyButton.style.display = "none";
    }
}
