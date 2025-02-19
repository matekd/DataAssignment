import React from "react"
import { NavLink } from "react-router-dom"

const Nav = () => {
  
  return (
    <>
      <nav>
        <NavLink to="/">View projects</NavLink>
        <NavLink to="/project">Create new project</NavLink>
      </nav>
    </>
  )
}

export default Nav