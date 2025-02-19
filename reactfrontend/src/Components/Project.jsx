import React from "react"
import { NavLink } from "react-router-dom"

const Project = ({p}) => {
  
  const RemoveProject = () => {
    alert("!")
  }

  return (
    <>
      <p>{p.name}</p>
      <p>{p.customerName}</p>
      <p>{p.employeeName}</p>
      <p>{p.serviceName}</p>
      
      <div className="buttons">
        <NavLink className="edit" to={`/project/${p.id}`}>Edit</NavLink>
        <button className="remove" onClick={RemoveProject}>Remove</button>
      </div>
    </>
  )
}

export default Project