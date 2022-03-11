import React from 'react'

function Payroll(props) {
    const {employeeId, employeeNameSurname, grandTotalSalary, identityNumber} = props.data;
  return (
    <table>
        <thead>
            <tr>
                <th>Employee ID</th>
                <th>Employee Name Surname</th>
                <th>Grand Total Salary</th>
                <th>Identity Number</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>{employeeId}</td>
                <td>{employeeNameSurname}</td>
                <td>{grandTotalSalary}</td>
                <td>{identityNumber}</td>
            </tr>
        </tbody>
    </table>
  )
}

export default Payroll