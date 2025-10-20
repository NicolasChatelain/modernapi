interface Window {
    __theme: 'light' | 'dark';
    __setPreferredTheme: (theme: 'light' | 'dark') => void;
}

interface User {
    id: number;
    userName: string;
    dateOfBirth: string;
}