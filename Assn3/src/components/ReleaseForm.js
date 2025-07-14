import React from "react";
import NavBar from "./NavBar";
NavBar
function ReleaseForm() {
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
      <p>Donating a pet can be hard, especially if you're quite close to them. But if that's what you wish to do, this from will formalize it:</p>
      <label>Enter your pet's name:
      <input 
        type="text" 
        name="petname" 
        value={inputs.username || ""} 
        onChange={handleChange}
      />
      </label>
      \n
      <label>Enter your pet's age:
        <input 
          type="number" 
          name="petage" 
          value={inputs.age || ""} 
          onChange={handleChange}
        />
        </label>
        \n
        <label>Enter your pet's type:
        <input 
          type="text" 
          name="pettype" 
          value={inputs.pettype || ""} 
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
root.render(<releaseForm />);
export default ReleaseForm;