import React, { useState, useEffect } from "react"

const ProjectRegistrationForm = () => {
  const [formData, setFormData] = useState({
    Name: "",
    Description: "",
    StartDate: "",
    EndDate: "",
    CustomerId: "",
    EmployeeId: "",
    ServiceId: "",
    StatusId: "",
  })
  const [customers, setCustomers] = useState([])
  const [employees, setEmployees] = useState([])
  const [services, setServices] = useState([])
  const [status, setStatus] = useState([])

  const fetchData = async (apiUrl, setter) => {
    const res = await fetch(apiUrl)
    const data = await res.json()
    setter(data)
  }

  useEffect(() => {
    fetchData("https://localhost:7123/api/customer", setCustomers)
  }, [])
  useEffect(() => {
    fetchData("https://localhost:7123/api/employee", setEmployees)
  }, [])
  useEffect(() => {
    fetchData("https://localhost:7123/api/service", setServices)
  }, [])
  useEffect(() => {
    fetchData("https://localhost:7123/api/statusType", setStatus)
  }, [])

  const handleChange = (e) => {
    const { name, value } = e.target
    if(name === "CustomerId" || name === "EmployeeId" || name === "ServiceId" || name === "StatusId")
      setFormData({...formData, [name]: Number(value)})
    else
      setFormData({...formData, [name]: value})
  }

  const handleSubmit = async (e) => {
    e.preventDefault()
    
    // validate form here
    if (formData.EndDate === "") {
      setFormData({
        ...formData,
        EndDate: null
      })
    }

    const res = await fetch('https://localhost:7123/api/project', {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(formData)
    })

    if (res.ok) {
      // return to home page?
      console.log("success")
    } else {
      console.log("fail")
      // alert error in some way
    }
    alert("!")
  }

  return (
    <>
      <form onSubmit={handleSubmit}>
        <label className="form-label">Project name <br />
          <input type="text" name="Name" value={formData.Name} onChange={handleChange}  autoComplete='off' required/>
        </label>

        <label className="form-label">Description <br />
          <textarea name="Description" rows="5" value={formData.Description} onChange={handleChange} autoComplete='off'/>
        </label>

        <label className="form-label">Start date <br />
          <input type="date" name="StartDate" value={formData.StartDate} onChange={handleChange} required/>
        </label>

        <label className="form-label">End date <br />
          <input type="date" name="EndDate" value={`${formData.EndDate !== null ? formData.EndDate : ''}`} onChange={handleChange} />
        </label>

        <label className="form-label">Customer <br />
          <select name="CustomerId" value={formData.CustomerId} onChange={handleChange} required>
            <option disabled hidden value=''></option>
            {customers.map((customer, index) => (
              <option key={index} value={customer.id}>{customer.name}</option>
            ))}
          </select>
        </label>

        <label className="form-label">Employee <br />
          <select name="EmployeeId" value={formData.EmployeeId} onChange={handleChange} required>
            <option disabled hidden value=''></option>
            {employees.length > 0 && employees.map((employee, index) => (
              <option key={index} value={employee.id}>{employee.name}</option>
            ))}
          </select>
        </label>

        <label className="form-label">Service <br />
          <select name="ServiceId" value={formData.ServiceId} onChange={handleChange} required>
            <option disabled hidden value=''></option>
            {services.map((service, index) => (
              <option key={index} value={service.id}>{service.name}</option>
            ))}
          </select>
        </label>

        <label className="form-label">Status <br />
          <select name="StatusId" value={formData.StatusId} onChange={handleChange} required>
            <option disabled hidden value=''></option>
            {status.map((status, index) => (
              <option key={index} value={status.id}>{status.status}</option>
            ))}
          </select>
        </label>

        <button type="submit">Create new project</button>
      </form>
    </>
  )
}

export default ProjectRegistrationForm