import { useEffect, useState } from "react";
import Table from "./components/Table";
import 'bootstrap/dist/css/bootstrap.min.css';
import "./App.css";

function App() {
  const [employees, setEmployees] = useState([]);

  useEffect(() => {
    fetch(process.env.REACT_APP_API_EMP_ENDPOINT)
      .then((response) => response.json())
      .then((data) => setEmployees(data.responseData.employees))
      .catch((error) => console.log(error));
  }, []);

  return (
    <div className="App">
        <Table employees={employees} />
    </div>
  );
}

export default App;
