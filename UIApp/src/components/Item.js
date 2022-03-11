import { useState } from "react";
import {Modal, Button} from 'react-bootstrap';
import Payroll from "./Payroll";

function Item(props) {
  const {
    employeeId,
    employeeType,
    identityNumber,
    name,
    surname,
    birthDate,
    mail,
  } = props.data;

  const [payroll, setPayroll] = useState({});
  const [isVisible, setIsVisible] = useState(false);

  function handlePayrollGeneration() {
    fetch(process.env.REACT_APP_API_PAYROLL_ENDPOINT + employeeId)
      .then((response) => response.json())
      .then((data) => setPayroll(data.responseData))
      .catch((error) => console.log(error));
    show();
  }

  function hide() {
    setIsVisible(false);
  }

  function show() {
    setIsVisible(true);
  }

  return (
    <>
      <tr>
        <td>{employeeId}</td>
        <td>{employeeType}</td>
        <td>{identityNumber}</td>
        <td>{name}</td>
        <td>{surname}</td>
        <td>{birthDate}</td>
        <td>{mail}</td>
        <td>
          <button onClick={handlePayrollGeneration}>Generate Payroll</button>
        </td>
      </tr>

      <Modal show={isVisible} onHide={hide}>
        <Modal.Header closeButton>
          <Modal.Title>{`${name} ${surname} Payroll`} </Modal.Title>
        </Modal.Header>
        <Modal.Body><Payroll data={payroll} /></Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={hide}>
            Close
          </Button>
        </Modal.Footer>
      </Modal>
    </>
  );
}

export default Item;
