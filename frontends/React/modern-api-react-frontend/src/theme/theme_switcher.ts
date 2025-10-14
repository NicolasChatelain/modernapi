export const getTheme = () => {
    const saved = localStorage.getItem("theme");
    if (saved) return saved;
    return window.matchMedia("(prefers-color-scheme: dark)").matches ? "dark" : "light";
}

export const applyTheme = (theme: string) => {
    document.documentElement.setAttribute("data-theme", theme);
    localStorage.setItem("theme", theme);
}

export const switchTheme = () => {
    const current_theme = getTheme();
    const new_theme = current_theme === "dark" ? "light" : "dark";
    applyTheme(new_theme);
}