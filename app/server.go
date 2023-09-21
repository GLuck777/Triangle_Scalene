package main

import (
	"fmt"
	"html/template"
	"net/http"
)

const port = ":8080"

func main() {
	// Import the css
	// cssHandler := http.FileServer(http.Dir("css"))
	// http.Handle("/css/", http.StripPrefix("/css/", cssHandler))

	// Page existing with her function
	http.HandleFunc("/", logHandler)
	// Server access
	fmt.Println("http://localhost:2525) - Server Started on port", port)
	http.ListenAndServe(port, nil)
}

func logHandler(w http.ResponseWriter, r *http.Request) {
	if r.URL.Path != "/" {
		fmt.Println(http.StatusNotFound, "Error executing template for index page")
		// Error(w, r, http.StatusNotFound)
		return
	}
	tmpl := template.Must(template.ParseFiles("index.html"))
	errHeader := tmpl.Execute(w, nil)
	if errHeader != nil {
		fmt.Println(http.StatusInternalServerError, "Error executing template for index page")
		// Error(w, r, http.StatusInternalServerError)
		return
	}
}
