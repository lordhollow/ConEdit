// This file was generated by Coco/R.
// Do not edit this file directly.
// (see 'misc/parsers' directory in source distribution)
using System;
using System.IO;
using System.Collections;
using Sgry.Azuki;
using Sgry.Azuki.Highlighter.Coco;

namespace Sgry.Azuki.Highlighter.Coco.Latex {

class Token {
	public int kind;    // token kind
	public int pos;     // token position in the source text (starting at 0)
	public int col;     // token column (starting at 1)
	public int line;    // token line (starting at 1)
	public string val;  // token value
	public Token next;  // ML 2005-03-11 Tokens are kept in linked list
}

//-----------------------------------------------------------------------------------
// Scanner
//-----------------------------------------------------------------------------------
class Scanner {
	const char EOL = '\n';
	const int eofSym = 0; /* pdt */
	const int maxT = 13;
	const int noSym = 13;


	public Buffer buffer; // scanner buffer

	Token t;          // current token
	int ch;           // current input character
	int pos;          // byte position of current character
	int col;          // column number of current character
	int line;         // line number of current character
	int oldEols;      // EOLs that appeared in a comment;
	//static readonly Hashtable start; // maps first token character to start state
	static sbyte[] start = null; // maps first token character to start state
	static int instanceCount = 0;
	
	Token tokens;     // list of tokens already peeked (first token is a dummy)
	Token pt;         // current peek token
	
	char[] tval = new char[128]; // text of current token
	int tlen;         // length of current token
	
	public Scanner( Document doc, int startIndex, int endIndex )
	{
		instanceCount++;
		buffer = new Buffer( doc, startIndex, endIndex );
		Init();
	}
	
	~Scanner()
	{
		instanceCount--;
		if( instanceCount <= 0 )
		{
			start = null;
		}
	}
	
	void Init() {
		pos = -1; line = 1; col = 0;
		oldEols = 0;
		NextCh();
		pt = tokens = new Token();  // first token is a dummy
		
		if( start == null )
		{
			start = new sbyte[ Char.MaxValue + 2 ];
		}
		for (int i = 0; i <= 8; ++i) start[i] = 9;
		for (int i = 11; i <= 12; ++i) start[i] = 9;
		for (int i = 14; i <= 31; ++i) start[i] = 9;
		for (int i = 33; i <= 35; ++i) start[i] = 9;
		for (int i = 38; i <= 90; ++i) start[i] = 9;
		for (int i = 94; i <= 122; ++i) start[i] = 9;
		for (int i = 124; i <= 124; ++i) start[i] = 9;
		for (int i = 126; i <= 65535; ++i) start[i] = 9;
		for (int i = 9; i <= 10; ++i) start[i] = 10;
		for (int i = 13; i <= 13; ++i) start[i] = 10;
		for (int i = 32; i <= 32; ++i) start[i] = 10;
		start[92] = 11; 
		start[36] = 2; 
		for (int i = 91; i <= 91; ++i) start[i] = 3;
		for (int i = 93; i <= 93; ++i) start[i] = 3;
		start[123] = 4; 
		start[125] = 5; 
		start[37] = 7; 
		start[Buffer.EOF] = -1;

	}
	
	void NextCh() {
		if (oldEols > 0) { ch = EOL; oldEols--; } 
		else {
			pos = buffer.Pos;
			ch = buffer.Read(); col++;
			// replace isolated '\r' by '\n' in order to make
			// eol handling uniform across Windows, Unix and Mac
			if (ch == '\r' && buffer.Peek() != '\n') ch = EOL;
			if (ch == EOL) { line++; col = 0; }
		}

	}

	void AddCh() {
		if (tlen >= tval.Length) {
			char[] newBuf = new char[2 * tval.Length];
			Array.Copy(tval, 0, newBuf, 0, tval.Length);
			tval = newBuf;
		}
		if (ch != Buffer.EOF) {
			tval[tlen++] = (char) ch;
			NextCh();
		}
	}




	void CheckLiteral() {
		switch (t.val) {
			case "\\section": t.kind = 2; break;
			case "\\subsection": t.kind = 3; break;
			case "\\subsubsection": t.kind = 4; break;
			default: break;
		}
	}

	Token NextToken() {
		#pragma warning disable 0162
		while (//ch == ' ' ||
			false
		) NextCh();
		#pragma warning restore 0162

		t = new Token();
		t.pos = pos; t.col = col; t.line = line; 
		int state;
		if( 0 <= ch && ch < start.Length )
			state = start[ch];
		else
			state = 0;
		tlen = 0;
		AddCh();
		
		switch (state) {
			case -1: { t.kind = eofSym; break; } // NextCh already done
			case 0: { t.kind = noSym; break; }   // NextCh already done
			case 1:
				if (ch >= 'A' && ch <= 'Z' || ch >= 'a' && ch <= 'z') {AddCh(); goto case 1;}
				else {t.kind = 1; t.val = new String(tval, 0, tlen); CheckLiteral(); return t;}
			case 2:
				{t.kind = 5; break;}
			case 3:
				{t.kind = 6; break;}
			case 4:
				{t.kind = 7; break;}
			case 5:
				{t.kind = 8; break;}
			case 6:
				{t.kind = 9; break;}
			case 7:
				if (ch <= 9 || ch >= 11 && ch <= 12 || ch >= 14 && ch <= 65535) {AddCh(); goto case 7;}
				else if (ch == 13) {AddCh(); goto case 12;}
				else if (ch == 10) {AddCh(); goto case 8;}
				else {t.kind = noSym; break;}
			case 8:
				{t.kind = 10; break;}
			case 9:
				if (ch <= 8 || ch >= 11 && ch <= 12 || ch >= 14 && ch <= 31 || ch >= '!' && ch <= '#' || ch >= '&' && ch <= 'Z' || ch >= '^' && ch <= 'z' || ch == '|' || ch >= '~' && ch <= 65535) {AddCh(); goto case 9;}
				else {t.kind = 11; break;}
			case 10:
				if (ch >= 9 && ch <= 10 || ch == 13 || ch == ' ') {AddCh(); goto case 10;}
				else {t.kind = 12; break;}
			case 11:
				if (ch >= 'A' && ch <= 'Z' || ch >= 'a' && ch <= 'z') {AddCh(); goto case 1;}
				else if (ch <= '@' || ch >= '[' && ch <= '`' || ch >= '{' && ch <= 65535) {AddCh(); goto case 6;}
				else {t.kind = noSym; break;}
			case 12:
				if (ch == 10) {AddCh(); goto case 8;}
				else {t.kind = 10; break;}

		}
		t.val = new String(tval, 0, tlen);
		return t;
	}
	
	// get the next token (possibly a token already seen during peeking)
	public Token Scan () {
		if (tokens.next == null) {
			return NextToken();
		} else {
			pt = tokens = tokens.next;
			return tokens;
		}
	}

	// peek for the next token, ignore pragmas
	public Token Peek () {
		do {
			if (pt.next == null) {
				pt.next = NextToken();
			}
			pt = pt.next;
		} while (pt.kind > maxT); // skip pragmas
	
		return pt;
	}

	// make sure that peeking starts at the current scan position
	public void ResetPeek () { pt = tokens; }

} // end Scanner

}