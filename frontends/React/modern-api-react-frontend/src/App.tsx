import { Table, TableBody, TableCaption, TableCell, TableHead, TableHeader, TableRow } from "./components/ui/table"
import { Button } from "./components/ui/button"
import { useState, useEffect } from "react";
import { Spinner } from "./components/ui/spinner";

function App() {

  const toggleTheme = () => {
    const currentTheme = window.__theme;
    const newTheme = currentTheme === "dark" ? "light" : "dark";
    window.__setPreferredTheme(newTheme);
  };

  const [users, setUsers] = useState<User[] | null>(null);
  const [loading, setLoading] = useState<boolean>(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    setLoading(true);
    fetch("http://localhost:5138/api/Users")
      .then(result => {
        if (!result.ok) {
          throw new Error("Failed to fetchdqsqdsqsdqdsqds");
        }
        return result.json();
      })
      .then(data => {
        setUsers(data);
        setLoading(false);
      })
      .catch(error => {
        setError(error.message);
        setLoading(false);
      });
  }, []);

  if (loading) {
    return (
      <div className="flex items-center justify-center min-h-screen">
        <Spinner className="size-10 text-amber-600" />
      </div>
    );
  }

  if (error) {
    return (
      <div className="flex items-center justify-center min-h-screen">
        <p className="text-amber-600 font-mono text-2xl">The table can not be loaded at this time.</p>
      </div>
    )
  }

  return (
    <>
      {/* <div>
        <Button onClick={toggleTheme}>Theme</Button>
      </div> */}
      <div className="flex items-center justify-center min-h-screen max-w-4xl mx-auto">
        <Table>
          <TableCaption>A list of users</TableCaption>
          <TableHeader>
            <TableRow>
              <TableHead className="text-amber-600">ID</TableHead>
              <TableHead>Username</TableHead>
              <TableHead>Date of birth</TableHead>
            </TableRow>
          </TableHeader>
          <TableBody>
            {
              users?.map(user => (
                <TableRow key={user.id}>
                  <TableCell className="text-amber-600">{user.id}</TableCell>
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
