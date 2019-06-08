using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Calc : MonoBehaviour
{
	public InputField input;
	public Text question;
	public Text statistics;
	System.Random r = new System.Random ();
	int solution, ok, fail;
	long time, solveTime;
	string[] w = {
		"null","eins","zwei","drei","vier","fünf","sechs","sieben","acht","neun",
		"zehn","elf","zwölf","dreizehn","vierzehn", "fünfzehn","sechszehn"
	};

	void Start ()
	{
		newQuestion ();
		time = System.DateTime.Now.Ticks;
	}

	string getQuestion (int a, string str, int b)
	{
		string strOp = 
			str=="+"? "plus":
			str=="x"? "mal":
			 "minus";
		return w[a] + " " + strOp +" "+ w[b];
	}

	void newQuestion ()
	{
		string q;
		int op = r.Next (3);
		int a = r.Next (12) + 3;
		int b = r.Next (12) + 3;
		if (op == 0) {
			q = getQuestion (a, "+", b);
			solution = a + b;
		} else if (op == 1) {
			q = getQuestion (a, "x", b);
			solution = a * b;
		} else {
			q = getQuestion (a, "-", b);
			solution = a - b;
		}
	

		statistics.text += "\n" + question.text + ": " + ((solveTime - time) / 10000000.0) + "s";
		question.text = q;
	}

	// Update is called once per frame
	void Update ()
	{
		int i;
		if (int.TryParse (input.text, out i)) {
			if (i == solution) {
				ok++;
				solveTime = System.DateTime.Now.Ticks;
				input.text = "";
				newQuestion ();
				time = System.DateTime.Now.Ticks;
			} else {
				fail++;
			}
		}
	}
}
