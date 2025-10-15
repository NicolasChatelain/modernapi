# Commands
### default classic start 
```bash
npm run dev
```

### default classic start + local network exposure

```bash
npm run dev -- --host
```

# Styling

### Theme switching

Script and style for :root element must be placed in the \<head\> of the index.html so that they may render before 
anything else is rendered. This way theme flash is avoided.

Implementation inspiration: React website.

Apparently a more robust way to avoid theme flash and handle theme switching is with the React library: **next-themes**.
I am not sure how next-themes works with system-preference themes.

### Install next-themes (works with Vite too):
```bash
npm install next-themes
```
### Wrap your app:
```typescript
// main.tsx
import { ThemeProvider } from 'next-themes'

ReactDOM.createRoot(document.getElementById('root')!).render(
  <ThemeProvider attribute="class" defaultTheme="system">
    <App />
  </ThemeProvider>
)
```
### Use the hook:
```typescript
// App.tsx
import { useTheme } from 'next-themes'

function App() {
  const { theme, setTheme } = useTheme()
  
  return (
    <button onClick={() => setTheme(theme === 'dark' ? 'light' : 'dark')}>
      Toggle
    </button>
  )
}
```