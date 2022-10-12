import React, { useState, useEffect } from "react"

const Employeelist = () => {
    const [employeeslist, setemployees] = useState(null)
    useEffect(() => {
        getemployees()
    }, [])
    const getemployees = () => {
        fetch("http://localhost:5059/Users")
            .then(res => res.json())
            .then(
                (result) => {                    
                    setemployees(result)
                },
                (error) => {
                    setemployees(null);
                }
            )
    }
    if (!employeeslist) return (<div>
        <h2>Register Here</h2>
        <table className="table" >
            <thead>
                <tr>
                    <th>Employee Id</th>
                    <th>Name</th>
                    <th>Surename</th>
                    <th>Birthdate</th>
                    <th>Email</th>
                </tr>
            </thead>
        </table>
    </div>)
    return (<div>
        <h2>Register Here</h2>
        <table className="table" >
            <thead>
                <tr>
                    <th>Employee Id</th>
                    <th>Name</th>
                    <th>Surename</th>
                    <th>Birthdate</th>
                    <th>Email</th>
                </tr>
            </thead>
            <tbody>
                {employeeslist.map(emp => (
                    <tr key={emp.id}>
                        <td>{emp.id}</td>
                        <td>{emp.name}</td>
                        <td>{emp.surname}</td>
                        <td>{emp.birthDate}</td>
                        <td>{emp.email}</td>
                    </tr>
                ))}
            </tbody>
        </table>
    </div>)
}
export default Employeelist;