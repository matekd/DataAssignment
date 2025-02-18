import React, { useState, useEffect } from "react"

const ProjectUpdateForm = ({id}) => {
  // All attributes start with lowercase due to api shenanigans
  const [formData, setFormData] = useState({
    name: "",
    description: "",
    startDate: "",
    endDate: "",
    customerId: "",
    employeeId: "",
    serviceId: "",
    statusId: "",
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
    fetchData(`https://localhost:7123/api/project/${id}`, setFormData)
  }, [])
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

    if(name === "customerId" || name === "employeeId" || name === "serviceId" || name === "statusId")
      setFormData({...formData, [name]: Number(value)})
    else
      setFormData({...formData, [name]: value})
  }

  const handleSubmit = async (e) => {
    e.preventDefault()
    
    // validate form here
    if (formData.endDate === "") {
      setFormData({
        ...formData,
        endDate: null
      })
    }
    if (formData.description === "") {
      setFormData({
        ...formData,
        description: null
      })
    }
    const updateForm = {
      Id: Number(id),
      Name: formData.name,
      Description: formData.description,
      StartDate: formData.startDate,
      EndDate: formData.endDate,
      CustomerId: formData.customerId,
      EmployeeId: formData.employeeId,
      ServiceId: formData.serviceId,
      StatusId: formData.statusId
    }
    const res = await fetch('https://localhost:7123/api/project', {
      method: 'PATCH',
      headers: {
        'Content-Type': 'application/json'
      },
      body: JSON.stringify(updateForm)
    })
  
    if (res.ok) {
      // return to home page?
      console.log("success")
    } else {
      console.log("fail")
      // alert error in some way
    }
  }
  
  return (
    <>
      <form onSubmit={handleSubmit}>
        <label className="form-label">Project name <br />
          <input type="text" name="name" value={formData.name} onChange={handleChange}  autoComplete='off' required/>
        </label>
  
        <label className="form-label">Description <br />
        {/* Cannot display null, must be empty string */}
          <textarea name="description" rows="5" value={`${formData.description !== null ? formData.description : ''}`} onChange={handleChange} autoComplete='off'/>
        </label>
  
        <label className="form-label">Start date <br />
          <input type="date" name="startDate" value={formData.startDate} onChange={handleChange} required/>
        </label>
  
        <label className="form-label">End date <br />
        {/* Cannot display null, must be empty string */}
          <input type="date" name="endDate" value={`${formData.endDate !== null ? formData.endDate : ''}`} onChange={handleChange} />
        </label>
  
        <label className="form-label">Customer <br />
          <select name="customerId" value={formData.customerId} onChange={handleChange} required>
            {customers.map((customer, index) => (
              <option key={index} value={customer.id}>{customer.name}</option>
            ))}
          </select>
        </label>
  
        <label className="form-label">Employee <br />
        {/* Selects the correct option since values match */}
          <select name="employeeId" value={formData.employeeId} onChange={handleChange} required>
            {employees.length > 0 && employees.map((employee, index) => (
              <option key={index} value={employee.id}>{employee.name}</option>
            ))}
          </select>
        </label>
  
        <label className="form-label">Service <br />
          <select name="serviceId" value={formData.serviceId} onChange={handleChange} required>
            {services.map((service, index) => (
              <option key={index} value={service.id}>{service.name}</option>
            ))}
          </select>
        </label>
  
        <label className="form-label">Status <br />
          <select name="statusId" value={formData.statusId} onChange={handleChange} required>
            {status.map((status, index) => (
              <option key={index} value={status.id}>{status.status}</option>
            ))}
          </select>
        </label>
  
        <button type="submit">Update project</button>
      </form>
    </>
  )
}

export default ProjectUpdateForm