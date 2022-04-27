using RuleEngine.Domain;

namespace RuleEngine.Playground
{
    public class ExpressionService
    {
        public Expression GenerateExpression()
        {
            var leftHandSide_A = new LeftHandSide("name");
            var rightHandSide_A = RightHandSide.Factor.NewText("wellington luiz do nascimento");
            var segment_A =  new Segment(leftHandSide_A, Operator.Equal ,rightHandSide_A);

            var leftHandSide_A2 = new LeftHandSide("input1.RelacaoEmpresarial");
            var rightHandSide_A2 = RightHandSide.Factor.NewAnotherField("input2.RelacaoEmpregaticia");
            var segment_A2 = new Segment(leftHandSide_A2, Operator.Equal ,rightHandSide_A2);

            var leftHandSide_B = new LeftHandSide("age");
            var rightHandSide_B = RightHandSide.Factor.NewInteger(18);
            var segment_B = new Segment(leftHandSide_B, Operator.GraterThan ,rightHandSide_B);

            var leftHandSide_C = new LeftHandSide("Money");
            var rightHandSide_C = RightHandSide.Factor.NewDecimal(150.5m);
            var segment_C = new Segment(leftHandSide_C, Operator.Less,rightHandSide_C);

            var leftHandSide_D = new LeftHandSide("Birthday");
            var rightHandSide_D = RightHandSide.Factor.NewDateTime(new DateTime(1985, 01, 18));
            var segment_D = new Segment(leftHandSide_D, Operator.Grater, rightHandSide_D);

            var leftHandSide_E = new LeftHandSide("ID");
            var rightHandSide_E = RightHandSide.Factor.NewGuid(Guid.NewGuid());
            var segment_E = new Segment(leftHandSide_E, Operator.NotEqual, rightHandSide_E);

            var leftHandSide_F = new LeftHandSide("States");
            var rightHandSide_F = RightHandSide.Factor.NewStringArray(new string[] { "são paulo", "rio de janeiro", "santa catarina" });
            var segment_F = new Segment(leftHandSide_F, Operator.IN,rightHandSide_F);

            var leftHandSide_G = new LeftHandSide("Days");
            var rightHandSide_G = RightHandSide.Factor.NewIntegerArray(new int[] { 10, 11, 12 });
            var segment_G = new Segment(leftHandSide_G, Operator.IN,rightHandSide_G);

            var expression = Expression.Factor.NewFromSegment(segment_A)
                                .Concat(segment_A2)
                                .Concat(segment_B)
                                .Concat(segment_C)
                                .Concat(segment_D)
                                .Concat(segment_E)
                                .Concat(segment_F)
                                .Concat(segment_G);

            return expression;
        }

        public Expression GenerateExpressionFromPattern(Expression expression)
        {
            var expressionFromPattern = Expression.Factor.NewFromPattern(expression.Pattern);
            return expressionFromPattern;
        }
    }
}