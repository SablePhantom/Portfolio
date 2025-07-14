import React from "react";
import NavBar from "./NavBar";
NavBar
function AdoptForm() {
  const [inputs, setInputs] = useState({});

  const handleChange = (event) => {
    const name = event.target.name;
    const value = event.target.value;
    setInputs(values => ({...values, [name]: value}))
  }

  const handleSubmit = (event) => {
    event.preventDefault();
    console.log(inputs);
  }

  return (
    <form onSubmit={handleSubmit}>
      <label>Enter your name:
      <input 
        type="text" 
        name="username" 
        value={inputs.username || ""} 
        onChange={handleChange}
      />
      </label>
      \n
      <label>Enter your age:
        <input 
          type="number" 
          name="age" 
          value={inputs.age || ""} 
          onChange={handleChange}
        />
        </label>
        \n
        <label>Enter your email:
        <input 
          type="text" 
          name="email" 
          value={inputs.email || ""} 
          onChange={handleChange}
        />
        </label>
        \n
        <label>Enter your phone number:
        <input 
          type="number" 
          name="phone" 
          value={inputs.phone || ""} 
          onChange={handleChange}
        />
        </label>
        \n
        <input type="submit" />
      <footer>
        <p>&copy; 2023 Pet Heaven. All rights reserved</p>
      </footer> 
    </form>
    
  )
}

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(<adoptionForm />);
export default AdoptForm;