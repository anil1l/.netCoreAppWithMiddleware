import Item from "./Item";
import "./styles.css";

function Table(props) {
  const { employees } = props;
  const items = employees.map((employee) => (
    <Item key={employee.employeeId} data={employee} />
  ));
  return (
    <table className="table">
      <thead>
        <tr>
          <th>Employee ID</th>
          <th>Employee Type</th>
          <th>Identity Number</th>
          <th>Name</th>
          <th>Surname</th>
          <th>Birth Date</th>
          <th>Mail</th>
        </tr>
      </thead>
      <tbody>{items}</tbody>
    </table>
  );
}

export default Table;
