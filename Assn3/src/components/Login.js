import React from "react";
import NavBar from "./NavBar";
import "./RegisterFunction.css";
NavBar
function Login() {
    const [name, setName] = useState('');
    const [password, setPassword] = useState('');

    const [submitted, setSubmitted] = useState(false);
    const [error, setError] = useState(false);
 
    // Handling the name change
    const handleName = (e) => {
        setName(e.target.value);
        setSubmitted(false);
    };
 
    // Handling the password change
    const handlePassword = (e) => {
        setPassword(e.target.value);
        setSubmitted(false);
    };
 
    // Handling the form submission
    const handleSubmit = (e) => {
        e.preventDefault();
        if (name === '' || password === '') {
            setError(true);
        } else {
            setSubmitted(true);
            setError(false);
        }
    };
 
    // Showing success message
    const successMessage = () => {
        return (
            <div
                className="success"
                style={{
                    display: submitted ? '' : 'none',
                }}>
                <h1>Welcome back, {name}!</h1>
            </div>
        );
    };
 
    // Showing error message if error is true
    const errorMessage = () => {
        return (
            <div
                className="error"
                style={{
                    display: error ? '' : 'none',
                }}>
                <h1>Please enter all the fields</h1>
            </div>
        );
    };
 
    return (
        <div className="form">
            <div>
                <h2>User Registration</h2>
            </div>
 
            {/* Calling to the methods */}
            <div className="messages">
                {errorMessage()}
                {successMessage()}
            </div>
 
            <form>
                {/* Labels and inputs for form data */}
                <label className="label">Name</label>
                <input onChange={handleName} className="input"
                    value={name} type="text" />
 
                <label className="label">Password</label>
                <input onChange={handlePassword} className="input"
                    value={password} type="password" />
 
                <button onClick={handleSubmit} className="btn"
                        type="submit">
                    Submit
                </button>
            </form>
        <p>Are you new here? You can register by clicking <Link to="/register">here</Link>.</p>
        <footer>
            <p>&copy; 2023 Pet Heaven. All rights reserved</p>
        </footer>
        </div>

    );
};
export default Login;