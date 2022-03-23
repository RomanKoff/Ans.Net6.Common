using System.Text;

namespace Ans.Net6.Common
{

	/// <summary>
	/// 
	/// </summary>
	public static class SuppHtml
	{

		/// <summary>
		/// 
		/// </summary>
		/// <param name="source"></param>
		/// <returns></returns>
		public static string GetEscapeHtml(
			string source)
		{
			return source
				.Replace("&", "&amp;")
				.Replace("<", "&lt;")
				.Replace(">", "&gt;");
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="sb"></param>
		public static void ReplaceHtmlMacros(
			StringBuilder sb)
		{
			_ = sb
				.Replace("<<<^", "”")
				.Replace("<<<", "„")
				.Replace(">>>", "“")
				.Replace("<<", "«")
				.Replace(">>", "»")
				.Replace("<--", "←")
				.Replace("-->", "→")
				.Replace("<==", "⇐")
				.Replace("==>", "⇒")
				.Replace("--", "—")
				.Replace("-^", "–")
				.Replace("...", "…")

				//-- General Punctuation
				.Replace("&ndash;", "–")        // EN DASH
				.Replace("&mdash;", "—")        // EM DASH
				.Replace("&oline;", "‾")        // OVERLINE

				.Replace("&lsquo;", "‘")        // LEFT SINGLE QUOTATION MARK
				.Replace("&rsquo;", "’")        // RIGHT SINGLE QUOTATION MARK
				.Replace("&sbquo;", "‚")        // SINGLE LOW-9 QUOTATION MARK
				.Replace("&ldquo;", "“")        // LEFT DOUBLE QUOTATION MARK
				.Replace("&rdquo;", "”")        // RIGHT DOUBLE QUOTATION MARK
				.Replace("&bdquo;", "„")        // DOUBLE LOW-9 QUOTATION MARK
				.Replace("&prime;", "′")        // PRIME
				.Replace("&Prime;", "″")        // DOUBLE PRIME
				.Replace("&lsaquo;", "‹")       // SINGLE LEFT-POINTING ANGLE QUOTATION MARK
				.Replace("&rsaquo;", "›")       // SINGLE RIGHT-POINTING ANGLE QUOTATION MARK
				.Replace("&laquo;", "«")
				.Replace("&raquo;", "»")

				.Replace("&tilde;", "˜")
				.Replace("&uml;", "¨")
				.Replace("&dagger;", "†")       // DAGGER
				.Replace("&Dagger;", "‡")       // DOUBLE DAGGER

				.Replace("&middot;", "·")
				.Replace("&bull;", "•")         // BULLET
				.Replace("&hellip;", "…")       // HORIZONTAL ELLIPSIS

				.Replace("&sect;", "§")
				.Replace("&para;", "¶")
				.Replace("&permil;", "‰")       // PER MILLE SIGN

				.Replace("&brvbar;", "¦")
				.Replace("&circ;", "ˆ")
				.Replace("&iexcl;", "¡")
				.Replace("&iquest;", "¿")
				.Replace("&macr;", "¯")
				.Replace("&cedil;", "¸")
				.Replace("&sdot;", "⋅")         // DOT OPERATOR
				.Replace("&acute;", "´")

				//-- Currency Symbols
				.Replace("&euro;", "€")         // EURO SIGN
				.Replace("&pound;", "£")
				.Replace("&rur;", "<i class=\"fa fa-rub\"></i>")
				.Replace("&yen;", "¥")
				.Replace("&cent;", "¢")
				.Replace("&curren;", "¤")

				//-- Letterlike Symbols
				.Replace("&reg;", "®")
				.Replace("&copy;", "©")
				.Replace("&trade;", "™")        // TRADE MARK SIGN
				.Replace("&image;", "ℑ")        // BLACK-LETTER CAPITAL I
				.Replace("&weierp;", "℘")       // SCRIPT CAPITAL P
				.Replace("&real;", "ℜ")         // BLACK-LETTER CAPITAL R				
				.Replace("&ohm;", "Ω")          // OHM SIGN
				.Replace("&mho;", "℧")          // INVERTED OHM SIGN
				.Replace("&alefsym;", "ℵ")      // ALEF SYMBOL

				//-- Arrows
				.Replace("&larr;", "←")         // LEFTWARDS ARROW
				.Replace("&uarr;", "↑")         // UPWARDS ARROW
				.Replace("&rarr;", "→")         // RIGHTWARDS ARROW
				.Replace("&darr;", "↓")         // DOWNWARDS ARROW
				.Replace("&harr;", "↔")         // LEFT RIGHT ARROW
				.Replace("&lArr;", "⇐")         // LEFTWARDS DOUBLE ARROW
				.Replace("&uArr;", "⇑")         // UPWARDS DOUBLE ARROW
				.Replace("&rArr;", "⇒")        // RIGHTWARDS DOUBLE ARROW
				.Replace("&dArr;", "⇓")         // DOWNWARDS DOUBLE ARROW
				.Replace("&hArr;", "⇔")        // LEFT RIGHT DOUBLE ARROW
				.Replace("&crarr;", "↵")        // DOWNWARDS ARROW WITH CORNER LEFTWARDS

				//-- Mathematical Operators
				.Replace("&minus;", "−")        // MINUS SIGN
				.Replace("&plusmn;", "±")
				.Replace("&times;", "×")
				.Replace("&frasl;", "⁄")        // FRACTION SLASH
				.Replace("&divide;", "÷")
				.Replace("&lowast;", "∗")       // ASTERISK OPERATOR
				.Replace("&int;", "∫")          // INTEGRAL
				.Replace("&radic;", "√")        // SQUARE ROOT
				.Replace("&asymp;", "≈")        // ALMOST EQUAL TO
				.Replace("&ne;", "≠")           // NOT EQUAL TO
				.Replace("&equiv;", "≡")        // IDENTICAL TO
				.Replace("&sim;", "∼")          // TILDE OPERATOR
				.Replace("&cong;", "≅")         // APPROXIMATELY EQUAL TO
				.Replace("&there4;", "∴")      // THEREFORE
				.Replace("&le;", "≤")           // LESS-THAN OR EQUAL TO
				.Replace("&ge;", "≥")           // GREATER-THAN OR EQUAL TO
				.Replace("&deg;", "°")
				.Replace("&sup1;", "¹")
				.Replace("&sup2;", "²")
				.Replace("&sup3;", "³")
				.Replace("&frac12;", "½")
				.Replace("&frac14;", "¼")
				.Replace("&frac34;", "¾")
				.Replace("&ordf;", "ª")
				.Replace("&ordm;", "º")
				.Replace("&prod;", "∏")         // N-ARY PRODUCT
				.Replace("&sum;", "∑")          // N-ARY SUMMATION
				.Replace("&part;", "∂")         // PARTIAL DIFFERENTIAL				
				.Replace("&forall;", "∀")      // FOR ALL
				.Replace("&exist;", "∃")       // THERE EXISTS
				.Replace("&nabla;", "∇")       // NABLA
				.Replace("&and;", "∧")         // LOGICAL AND
				.Replace("&or;", "∨")          // LOGICAL OR
				.Replace("&not;", "¬")
				.Replace("&cap;", "∩")          // INTERSECTION
				.Replace("&cup;", "∪")         // UNION				
				.Replace("&sub;", "⊂")         // SUBSET OF
				.Replace("&isin;", "∈")        // ELEMENT OF
				.Replace("&sube;", "⊆")        // SUBSET OF OR EQUAL TO
				.Replace("&nsub;", "⊄")         // NOT A SUBSET OF				
				.Replace("&notin;", "∉")        // NOT AN ELEMENT OF
				.Replace("&sup;", "⊃")         // SUPERSET OF				
				.Replace("&ni;", "∋")          // CONTAINS AS MEMBER
				.Replace("&supe;", "⊇")        // SUPERSET OF OR EQUAL TO
				.Replace("&empty;", "∅")        // EMPTY SET
				.Replace("&oplus;", "⊕")        // CIRCLED PLUS
				.Replace("&otimes;", "⊗")       // CIRCLED TIMES
				.Replace("&prop;", "∝")        // PROPORTIONAL TO
				.Replace("&infin;", "∞")        // INFINITY
				.Replace("&ang;", "∠")         // ANGLE
				.Replace("&perp;", "⊥")        // UP TACK				
				.Replace("&fnof;", "ƒ")
				.Replace("&Oslash;", "Ø")
				.Replace("&pi;", "π")
				.Replace("&micro;", "µ")
				.Replace("&loz;", "◊")          // LOZENGE

				.Replace("&spades;", "♠")       // BLACK SPADE SUIT
				.Replace("&clubs;", "♣")        // BLACK CLUB SUIT
				.Replace("&hearts;", "♥")       // BLACK HEART SUIT
				.Replace("&diams;", "♦")        // BLACK DIAMOND SUIT
				;
		}

	}

}
