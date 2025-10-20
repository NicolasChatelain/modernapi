import { Table, TableBody, TableCaption, TableCell, TableHead, TableHeader, TableRow } from "./components/ui/table"
import { Button } from "./components/ui/button"
import { useState, useEffect } from "react";

function App() {

  const toggleTheme = () => {
    const currentTheme = window.__theme;
    const newTheme = currentTheme === "dark" ? "light" : "dark";
    window.__setPreferredTheme(newTheme);
  };

  const [users, setUsers] = useState<User[] | null>(null);

  useEffect(() => {
    fetch("http://localhost:5138/api/Users")
      .then(result => {
        if (!result.ok) {
          setUsers(null);
        }
        return result.json();
      }).then(data => { setUsers(data); });
  }, []);

  return (
    <>
      <div>
        <Button onClick={toggleTheme}>Theme</Button>
      </div>
      <div className="max-w-4xl w-full mx-auto">
        <Table>
          <TableCaption>A list of users</TableCaption>
          <TableHeader>
            <TableRow>
              <TableHead>ID</TableHead>
              <TableHead>Username</TableHead>
              <TableHead>Date of birth</TableHead>
            </TableRow>
          </TableHeader>
          <TableBody>
              {
                users?.map(user => (
                  <TableRow key={user.id}>
                    <TableCell>{user.id}</TableCell>
                    <TableCell>{user.userName}</TableCell>
                    <TableCell>{user.dateOfBirth}</TableCell>
                  </TableRow>
                ))
              }
          </TableBody>
        </Table>
      </div>
    </>
  )
}

export default App
