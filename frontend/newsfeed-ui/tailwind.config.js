/** @type {import('tailwindcss').Config} */  
export default {  
  content: [  
    "./src/**/*.{js,jsx,ts,tsx}",  
  ],  
  theme: {  
    extend: {
      maxHeight: {
        '128': '32rem',
      }
    },  
  },  
  plugins: [],  
};