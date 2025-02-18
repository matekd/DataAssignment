import React from "react"
import { useParams } from 'react-router-dom'
import ProjectUpdateForm from "../Components/ProjectUpdateForm"

const ProjectEdit = () => {
  const { projectId } = useParams()

  return (
    <>
      <ProjectUpdateForm id={projectId}/>
    </>
  )
}

export default ProjectEdit