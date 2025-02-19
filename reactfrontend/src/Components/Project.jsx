import React from "react"
import { NavLink } from "react-router-dom"

// project p, removeProject rp (from parent state list)
const Project = ({p, rp}) => {
  
  const RemoveProject = async () => {
    const res = await fetch(`https://localhost:7123/api/project?id=${p.id}`, {
      method: 'DELETE'
    })

    if (res.ok) {
      // return to home page?
      console.log("success")
      rp(p.id)
    } else {
      console.log("fail")
      // alert error in some way
    }
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