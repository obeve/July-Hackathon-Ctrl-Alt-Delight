// Small JS interop helpers for the Blazor app.
window.focusElementById = (id) => {
  try {
    const el = document.getElementById(id);
    if (el && typeof el.focus === 'function') {
      el.focus();
    }
  } catch (e) {
    // Fail silently — interop called as enhancement only.
    console.error('focusElementById error', e);
  }
};
